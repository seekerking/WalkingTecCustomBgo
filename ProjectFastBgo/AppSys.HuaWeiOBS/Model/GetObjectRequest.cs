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
using OBS.Internal;
using System;
namespace OBS.Model
{
    /// <summary>
    /// ���ض�������������
    /// </summary>
    public class GetObjectRequest : GetObjectMetadataRequest
    {

        internal override string GetAction()
        {
            return "GetObject";
        }

        private double _metric;

        /// <summary>
        /// ���ؽ��ȷ�����ʽ��Ĭ��ΪByBytes��
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ������������DownloadProgressʱ��Ч��
        /// </para>
        /// </remarks>
        public ProgressTypeEnum ProgressType
        {
            get;
            set;
        }

        /// <summary>
        /// ���ؽ��ȷ��������Ĭ��Ϊ100KB��1�롣
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ������������DownloadProgressʱ��Ч��
        /// </para>
        /// </remarks>
        public double ProgressInterval
        {
            get
            {
                return this._metric <= 0 ? (ProgressType == ProgressTypeEnum.ByBytes ? Constants.DefaultProgressUpdateInterval : 1) : this._metric;
            }
            set
            {
                this._metric = value;
            }
        }

        /// <summary>
        /// ���ؽ��Ȼص�������
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public EventHandler<TransferStatus> DownloadProgress
        {
            get;
            set;
        }

        /// <summary>
        /// ��������ETagֵ��ò���ֵ��ͬ���򷵻ض������ݣ����򷵻��쳣�롣
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public string IfMatch
        {
            get;
            set;
        }


        /// <summary>
        /// ���������޸�ʱ�����ڸò���ֵָ����ʱ�䣬�򷵻ض������ݣ����򷵻��쳣�롣
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public DateTime? IfModifiedSince
        {
            get;
            set;
        }


        /// <summary>
        /// ��������ETagֵ��ò���ֵ����ͬ���򷵻ض������ݣ����򷵻��쳣�롣
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public string IfNoneMatch
        {
            get;
            set;
        }


        /// <summary>
        /// ���������޸�ʱ�����ڸò���ֵָ����ʱ�䣬�򷵻ض������ݣ����򷵻��쳣�롣
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public DateTime? IfUnmodifiedSince
        {
            get;
            set;
        }


       

        /// <summary>
        /// ���ض���ķ�Χ��
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public ByteRange ByteRange
        {
            get;
            set;
        }

        /// <summary>
        /// ��д����Ӧͷ��Ϣ��
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public ResponseHeaderOverrides ResponseHeaderOverrides
        {
            get;
            set;
        }


        /// <summary>
        /// ͼƬ���������
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public string ImageProcess
        {
            get;
            set;
        }


    }
}
    
