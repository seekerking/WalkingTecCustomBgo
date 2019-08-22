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
using System.Collections.Generic;

namespace OBS.Model
{
    /// <summary>
    /// ���ƶε����������
    /// </summary>
    public class CopyPartRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "CopyPart";
        }

        /// <summary>
        /// ԴͰ����
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public string SourceBucketName
        {
            get;
            set;
        }


        /// <summary>
        /// Դ��������
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public string SourceObjectKey
        {
            get;
            set;
        }


        /// <summary>
        /// Դ����İ汾�š�
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public string SourceVersionId
        {
            get;
            set;
        }

      

        /// <summary>
        /// Ŀ���������
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public string ObjectKey
        {
            get;
            set;
        }

        /// <summary>
        /// �ֶ��ϴ������ID�š�
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public string UploadId
        {
            get;
            set;
        }


        /// <summary>
        /// Ŀ��εķֶκš�
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public int PartNumber
        {
            get;
            set;
        }

        /// <summary>
        /// ����Դ����ķ�Χ��
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
        /// Դ����SSE-C����ͷ����Ϣ��
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public SseCHeader SourceSseCHeader
        {
            get;
            set;
        }

        /// <summary>
        /// ������SSE-C����ͷ����Ϣ��
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public SseCHeader DestinationSseCHeader
        {
            get;
            set;
        }

    }
}
    
