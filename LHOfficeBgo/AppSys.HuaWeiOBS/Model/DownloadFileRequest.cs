/*----------------------------------------------------------------------------------
// Copyright 2019 Huawei Technologies Co.,Ltd.
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License.  You may obtain a copy of the
// License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
// CONDITIONS OF ANY KIND, either express or implied.  See the License for the
// specific language governing permissions and limitations under the License.
//----------------------------------------------------------------------------------*/
using System;

namespace OBS.Model
{
    /// <summary>
    /// �����ļ������������
    /// </summary>
    public class DownloadFileRequest : GetObjectRequest
    {
        internal override string GetAction()
        {
            return "DownloadFile";
        }

        // �ֶ�����ʱ����󲢷�����Ĭ��Ϊ1
        private int taskNum = 1;

        // ��Ƭ��С����λ�ֽڣ�Ĭ��5M
        private long partSize = 5 * 1024 * 1024L;

        /// <summary>
        /// ���캯����
        /// </summary>
        public DownloadFileRequest()
        { }

        /// <summary>
        /// ���캯����
        /// </summary>
        /// <param name="bucketName">Ͱ����</param>
        /// <param name="objectKey">��������</param>
        public DownloadFileRequest(string bucketName, string objectKey)
        {
            this.BucketName = bucketName;
            this.ObjectKey = objectKey;
        }

        /// <summary>
        /// ���캯����
        /// </summary>
        /// <param name="bucketName">Ͱ����</param>
        /// <param name="objectKey">��������</param>
        /// <param name="downloadFile">���ض���ı����ļ�ȫ·����</param>
        public DownloadFileRequest(string bucketName, string objectKey, string downloadFile)
            : this(bucketName, objectKey)
        {
            this.DownloadFile = downloadFile;
        }

        /// <summary>
        /// ���캯����
        /// </summary>
        /// <param name="bucketName">Ͱ����</param>
        /// <param name="objectKey">��������</param>
        /// <param name="downloadFile">���ض���ı����ļ�ȫ·����</param>
        /// <param name="partSize">�ֶδ�С��</param>
        public DownloadFileRequest(string bucketName, string objectKey, string downloadFile, long partSize)
            :this(bucketName, objectKey)
        {
            this.DownloadFile = downloadFile;
            this.partSize = partSize;
        }

        /// <summary>
        /// ���캯����
        /// </summary>
        /// <param name="bucketName">Ͱ����</param>
        /// <param name="objectKey">��������</param>
        /// <param name="downloadFile">���ض���ı����ļ�ȫ·����</param>
        /// <param name="partSize">�ֶδ�С��</param>
        /// <param name="taskNum">��Ƭ�ϴ��߳�����</param>
        /// <param name="enableCheckpoint">�Ƿ����ϵ�����ģʽ��</param>
        public DownloadFileRequest(string bucketName, string objectKey, string downloadFile, long partSize, int taskNum,
                bool enableCheckpoint): this(bucketName, objectKey, downloadFile, partSize, taskNum, enableCheckpoint, null)
        {           
        }

        /// <summary>
        /// ���캯����
        /// </summary>
        /// <param name="bucketName">Ͱ����</param>
        /// <param name="objectKey">��������</param>
        /// <param name="downloadFile">���ض���ı����ļ�ȫ·����</param>
        /// <param name="partSize">�ֶδ�С��</param>
        /// <param name="taskNum">��Ƭ�ϴ��߳�����</param>
        /// <param name="enableCheckpoint">�Ƿ����ϵ�����ģʽ��</param>
        /// <param name="checkpointFile">��¼���ؽ��ȵ��ļ���</param>
        public DownloadFileRequest(string bucketName, string objectKey, string downloadFile, long partSize, int taskNum,
                bool enableCheckpoint, string checkpointFile)
            : this(bucketName, objectKey)
        {
            this.partSize = partSize;
            this.DownloadFile = downloadFile;
            this.EnableCheckpoint = enableCheckpoint;
            this.CheckpointFile = checkpointFile;
            this.taskNum = taskNum;
        }

        /// <summary>
        /// ���캯����
        /// </summary>
        /// <param name="bucketName">Ͱ����</param>
        /// <param name="objectKey">��������</param>
        /// <param name="downloadFile">���ض���ı����ļ�ȫ·����</param>
        /// <param name="partSize">�ֶδ�С��</param>
        /// <param name="enableCheckpoint">�Ƿ����ϵ�����ģʽ��</param>
        /// <param name="checkpointFile">��¼���ؽ��ȵ��ļ���</param>
        /// <param name="versionId">����汾�š�</param>
        public DownloadFileRequest(string bucketName, string objectKey, string downloadFile, long partSize, 
                bool enableCheckpoint, string checkpointFile, string versionId)
            : this(bucketName, objectKey)
        {
            this.partSize = partSize;
            this.DownloadFile = downloadFile;
            this.EnableCheckpoint = enableCheckpoint;
            this.CheckpointFile = checkpointFile;
            this.VersionId = versionId;
        }


        /// <summary>
        /// �����¼��ص���
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public EventHandler<ResumableDownloadEvent> DownloadEventHandler
        {
            get;
            set;
        }


        /// <summary>
        /// �ֶ�����ʱ����󲢷���
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��Ĭ��Ϊ1
        /// </para>
        /// </remarks>
        public int TaskNum
        {
            get { return this.taskNum; }
            set
            {
                if (value < 1)
                    this.taskNum = 1;
                else
                    this.taskNum = value;
            }
        }

        /// <summary>
        /// �ֶδ�С��
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ����λ�ֽڣ�ȡֵ��Χ��100KB~5GB��Ĭ��Ϊ5M��
        /// </para>
        /// </remarks>
        public long DownloadPartSize
        {
            get { return this.partSize; }
            set
            {
                if (value < 100 * 1024L)
                    this.partSize = 100 * 1024L;
                else if (value > 5 * 1024 * 1024 * 1024L)
                    this.partSize = 5 * 1024 * 1024 * 1024L;
                else
                    this.partSize = value;
            }
        }

        /// <summary>
        /// �ֶδ�С��
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ����λ�ֽڣ�ȡֵ��Χ��100KB~5GB��Ĭ��Ϊ5M��
        /// </para>
        /// </remarks>
        [Obsolete]
        public long PartSize
        {
            get
            {
                return this.DownloadPartSize;
            }
            set
            {
                this.DownloadPartSize = value;
            }
        }

        /// <summary>
        /// ���ض���ı����ļ�ȫ·����
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ������ֵΪ��ʱ��Ĭ��Ϊ��ǰ���������Ŀ¼��
        /// </para>
        /// </remarks>
        public string DownloadFile
        {
            get;
            set;
        }

        /// <summary>
        /// �Ƿ����ϵ�����ģʽ��
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��Ĭ��Ϊfalse����ʾ��������
        /// </para>
        /// </remarks>
        public bool EnableCheckpoint
        {
            get;
            set;
        }

        /// <summary>
        /// ��¼���ؽ��ȵ��ļ���
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��ֻ�ڶϵ�����ģʽ����Ч������ֵΪ��ʱ��Ĭ�������ض���ı����ļ�·��ͬĿ¼��
        /// </para>
        /// </remarks>
        public string CheckpointFile
        {
            get;
            set;
        }

        /// <summary>
        /// ����ʱ����ʱ�ļ���
        /// </summary>
        public string TempDownloadFile
        {
            get { return DownloadFile + ".tmp"; }
        }
    }
}

