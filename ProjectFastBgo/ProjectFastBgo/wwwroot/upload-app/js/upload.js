Vue.component('vue-uploader', {
    data: function () {
        return {
            fileName: '',
            fileSize: '',
            progress: 0,
            uploadTime: '',
            uploadSpeed: 0,
            uploadFileName: '',
            uploadId: '',
            isAbort: false,
            isUploading: false,
            obsClient: null
        }
    },

    props: ['file', 'accessKey', 'secretKey', 'server', 'bucket', 'fileBaseUrl'],

    created: function () {
        this.initUploader();
    },

    computed: {
        progressText: function () {
            return this.progress === '100.0' ? '已完成' : this.progress + '%'
        }
    },

    methods: {
        // 初始化
        initUploader: function () {
            // 创建ObsClient实例
            this.obsClient = new ObsClient({
                access_key_id: this.accessKey,
                secret_access_key: this.secretKey,
                server: this.server
            });
        },

        // 设置上传状态
        setUploadStatus: function (transferredAmount, totalAmount, totalSeconds) {
            var progress = (transferredAmount * 100.0 / totalAmount).toFixed(1)
            this.uploadTime = totalSeconds >= 60
                ? Math.floor(totalSeconds / 60) + '分' + Math.floor(totalSeconds % 60) + '秒'
                : Math.floor(totalSeconds % 60) + '秒'
            this.progress = progress;
            this.uploadSpeed = Math.ceil(transferredAmount * 1.0 / totalSeconds / 1024)
        },

        handleFileChange: function (e) {
            var _this = this
            // 取消之前的下载
            if (_this.uploadId) {
                _this.obsClient.abortMultipartUpload({
                    Bucket: _this.bucket,
                    Key: _this.uploadFileName,
                    UploadId: _this.uploadId,
                }, function (err, result) {
                    if (err) {
                        console.log('Error-->' + err);
                    } else {
                        _this.uploadId = ''
                        console.log('Status-->' + result);
                    }
                });
                _this.isAbort = true;
                _this.isUploading = false;
            }
            this.fileName = e.target.files[0].name
            var fileSize = e.target.files[0].size / 1024  // KB
            this.fileSize = fileSize > 1024 * 1024
                ? (fileSize / 1024 / 1024).toFixed(2) + 'G'
                : fileSize > 1024 ? (fileSize / 1024).toFixed(2) + 'M'
                    : fileSize.toFixed(2) + 'KB';
            this.uploadSpeed = 0;
            this.uploadTime = '';
            this.progress = 0;
        },

        triggerSuccess: function (fileName) {
            this.$emit('success', this.fileBaseUrl + '/' + fileName)
        },

        getGuid: function () {
            function S4() {
                return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
            }
            // then to call it, plus stitch in '4' in the third group
            guid = (S4() + S4() + "-" + S4() + "-4" + S4().substr(0, 3) + "-" + S4() + "-" + S4() + S4() + S4()).toLowerCase();
            return guid;

        },

        // 生成唯一的文件名
        generateFileName: function () {
            var arr = this.fileName.split('.')
            arr.splice(arr.length - 1, 0, this.getGuid())
            var fileName = arr.join('.');
            this.uploadFileName = fileName
            return fileName
        },

        // 开始上传任务
        upload: function () {
            var _this = this;

            if (_this.isUploading) {
                return;
            }

            var cp;
            var hook;
            var isAbort = false;
            var obsClient = this.obsClient;
            _this.isAbort = false;
            _this.isUploading = true;

            obsClient.uploadFile({
                Bucket: _this.bucket,
                Key: _this.generateFileName(),
                SourceFile: document.getElementById('vue-uploader-file').files[0],
                PartSize: 9 * 1024 * 1024,
                ProgressCallback: function (transferredAmount, totalAmount, totalSeconds) {
                    if (_this.isAbort) {
                        isAbort = true
                    }
                    if (!isAbort) {
                        _this.setUploadStatus(transferredAmount, totalAmount, totalSeconds)
                    }
                    // if(hook && (transferredAmount / totalAmount) > 0.5){
                    //   // 暂停断点续传任务
                    //   hook.cancel();
                    // }
                },
                EventCallback: function (eventType, eventParam, eventResult) {
                    if (eventType === 'initiateMultipartUploadSucceed') {
                        _this.uploadId = eventParam.uploadId
                    }
                    // 处理事件响应
                },
                ResumeCallback: function (resumeHook, uploadCheckpoint) {
                    // 获取取消断点续传上传任务控制参数
                    hook = resumeHook;
                    // 记录断点
                    cp = uploadCheckpoint;
                }
            }, function (err, result) {
                console.error('Error-->' + err);
                // 出现错误，再次调用断点续传接口，继续上传任务
                if (err) {
                    obsClient.uploadFile({
                        UploadCheckpoint: cp,
                        ProgressCallback: function (transferredAmount, totalAmount, totalSeconds) {
                            if (_this.isAbort) {
                                isAbort = true
                            }
                            if (!isAbort) {
                                _this.setUploadStatus(transferredAmount, totalAmount, totalSeconds)
                            }
                        },
                        EventCallback: function (eventType, eventParam, eventResult) {
                            if (eventType === 'initiateMultipartUploadSucceed') {
                                _this.uploadId = eventParam.uploadId
                            }
                        },
                    }, function (err, result) {
                        if (err) {
                            console.error('Error-->' + err);
                        } else {
                            if (result.CommonMsg.Status < 300) {
                                _this.triggerSuccess(result.InterfaceResult.Key);
                                _this.isUploading = false;
                                console.log('Key-->' + result.InterfaceResult.Key);
                                console.log('Location-->' + result.InterfaceResult.Location);
                            } else {
                                console.log('Code-->' + result.CommonMsg.Code);
                                console.log('Message-->' + result.CommonMsg.Message);
                            }
                        }
                    });
                } else {
                    console.log('Status-->' + result.CommonMsg.Status);
                    if (result.CommonMsg.Status < 300 && result.InterfaceResult) {
                        _this.triggerSuccess(result.InterfaceResult.Key);
                        _this.isUploading = false;
                        console.log('RequestId-->' + result.InterfaceResult.RequestId);
                    }
                }
            });
        }
    }
    ,
    template: `<div class="wnl-upload-wrap">
    <div class="wnl-btn-group">
      <div class="wnl-upload">
        <div class="wnl-button">+选择文件</div>
        <input class="wnl-file"type="file" name="" id="vue-uploader-file" @change="handleFileChange">
      </div>
      <div class="wnl-button2" @click="upload">上传</div>
    </div>
    <div class="wnl-upload-info" v-if="!!fileName">
        <table class="wnl-upload-table">
            <thead>
                <tr>
                    <th>文件名</th>
                    <th>文件大小</th>
                    <th>上传速度</th>
                    <th>用时</th>
                    <th>上传状态</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>{{ fileName }}</td>
                    <td>{{ fileSize }}</td>
                    <td>{{ uploadSpeed }}KB/s</td>
                    <td>{{ uploadTime }}</td>
                    <td>
                        <div class="wnl-progress-wrap">
                            <div class="wnl-progress" :style="{ width: progress + '%' }"></div>
                        </div>
                        <div class="wnl-progress-text">{{ progressText }}</div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</div>`
})