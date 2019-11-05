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
    /// ���ƶ�������������
    /// </summary>
    public class CopyObjectRequest : PutObjectBasicRequest
    {

        internal override string GetAction()
        {
            return "CopyObject";
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
        /// ���Դ�����ETagֵ��ò���ֵ��ͬ������и��ƣ����򷵻��쳣�롣
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
        /// ���Դ�����ETagֵ��ò���ֵ����ͬ������и��ƣ����򷵻��쳣�롣
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
        /// ���Դ������޸�ʱ�����ڸò���ֵָ����ʱ�䣬����и��ƣ����򷵻��쳣�롣
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
        /// ���Դ������޸�ʱ�����ڸò���ֵָ����ʱ�䣬����и��ƣ����򷵻��쳣�롣
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
        /// ���Ʋ��ԡ�
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public MetadataDirectiveEnum MetadataDirective
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

    }
}
    
