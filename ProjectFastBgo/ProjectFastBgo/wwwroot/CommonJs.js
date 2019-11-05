

///创建华为云上传实例
function getObsClient() {
    /*
    * Initialize a obs client instance with your account for accessing OBS
    */
    var ak ="XUGWR6RI34BX4IPB6KBN";
    var sk = "ycHfTd2ehvE4ToEqEBCoBn0CmTDa9erfw9CXWefJ";
    var server = "https://obs.cn-north-4.myhuaweicloud.com";
    return new ObsClient({
        access_key_id: ak,
        secret_access_key: sk,
        server: server,
        timeout: 60 * 5,
    });
}

function UploadFile(options) {
    var cp;
    var hook;
    var obsClient = getObsClient();
    var initOptions = {
        Key: Guid() + "."+options.SourceFile.name.split(".")[1],
        PartSize: 9 * 1024 * 1024,
        ProgressCallback: function (transferredAmount, totalAmount, totalSeconds) {
            console.log(transferredAmount * 1.0 / totalSeconds / 1024);
            console.log(transferredAmount * 100.0 / totalAmount);
            if (hook && (transferredAmount / totalAmount) > 0.5) {
                // 暂停断点续传任务
                hook.cancel();
            }
        },
        EventCallback: function (eventType, eventParam, eventResult) {
            // 处理事件响应
        },
        ResumeCallback: function (resumeHook, uploadCheckpoint) {
            // 获取取消断点续传上传任务控制参数
            hook = resumeHook;
            // 记录断点
            cp = uploadCheckpoint;
        }
    };
    initOptions = $.extend(initOptions, options, true);




    obsClient.uploadFile(initOptions, function (err, result) {
        console.error('Error-->' + err);
        // 出现错误，再次调用断点续传接口，继续上传任务
        if (err) {
            obsClient.uploadFile({
                UploadCheckpoint: cp,
                ProgressCallback: function (transferredAmount, totalAmount, totalSeconds) {
                    console.log(transferredAmount * 1.0 / totalSeconds / 1024);
                    console.log(transferredAmount * 100.0 / totalAmount);
                },
                EventCallback: function (eventType, eventParam, eventResult) {
                    // 处理事件响应
                },
            }, function (err, result) {
                if (err) {
                    console.error('Error-->' + err);
                } else {
                    if (result.CommonMsg.Status < 300) {
                        console.log('RequestId-->' + result.InterfaceResult.RequestId);
                        console.log('Bucket-->' + result.InterfaceResult.Bucket);
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
                console.log('RequestId-->' + result.InterfaceResult.RequestId);
            }
        }
    });
}



function Guid() {
    function S4() {
        return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
    }

    // then to call it, plus stitch in '4' in the third group
    guid = (S4() + S4() + "-" + S4() + "-4" + S4().substr(0, 3) + "-" + S4() + "-" + S4() + S4() + S4()).toLowerCase();
    return guid;
}

function getQueryString(name) {
    var str = location.href; //取得整个地址栏
    var num = str.indexOf("?")
    str = str.substr(num + 1)
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var reg_rewrite = new RegExp("(^|/)" + name + "/([^/]*)(/|$)", "i");
    var r = str.match(reg);
    var q = window.location.pathname.substr(1).match(reg_rewrite);
    if (r != null) {
        return unescape(r[2]);
    } else if (q != null) {
        return unescape(q[2]);
    } else {
        return null;
    }
}
var parseQueryString = function (url) {
    var reg_url = /^[^\?]+\?([\w\W]+)$/,
        reg_para = /([^&=]+)=([\w\W]*?)(&|$)/g, //g is very important
        arr_url = reg_url.exec(url),
        ret = {};
    if (arr_url && arr_url[1]) {
        var str_para = arr_url[1], result;
        while ((result = reg_para.exec(str_para)) != null) {
            ret[result[1]] = result[2];
        }
    }
    return ret;
}
function GetUrlParam() {
    var urlArr = globalData.url.split('?');
    var urlParam = '';
    if (urlArr.length > 1) {
        urlParam = '?' + urlArr[1];
    }
    return urlParam;
}

var globalData = {};