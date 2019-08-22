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
using System.Collections.Generic;

namespace OBS.Model
{
    /// <summary>
    /// �о�Ͱ�ڶ������Ӧ�����
    /// </summary>
    public class ListObjectsResponse : ObsWebServiceResponse
    {

        private IList<ObsObject> contents;

        private IList<string> commonPrefixes;


        /// <summary>
        /// �ж��оٽ���Ƿ񱻽ضϡ�
        /// true��ʾ�ضϣ�����û�з���ȫ�������false��ʾδ�ضϣ������Ѿ�������ȫ�������
        /// </summary>
        public bool IsTruncated
        {
            get;
            internal set;
        }

        /// <summary>
        /// �����������ʼλ�á�
        /// </summary>
        public string Marker
        {
            get;
            internal set;
        }

        /// <summary>
        /// �´��������ʼλ�á�
        /// </summary>
        public string NextMarker
        {
            get;
            internal set;
        }

        /// <summary>
        /// Ͱ�ڶ����б�
        /// </summary>
        public IList<ObsObject> ObsObjects
        {
            get {
                
                return this.contents ?? (this.contents = new List<ObsObject>()); }
            internal set { this.contents = value; }
        }

        /// <summary>
        /// Ͱ����
        /// </summary>
        public string BucketName
        {
            get;
            internal set;
        }


        /// <summary>
        /// ��������Ķ�����ǰ׺��
        /// </summary>
        public string Prefix
        {
            get;
            internal set;
        }


        /// <summary>
        /// ��������������Ŀ����
        /// </summary>
        public int? MaxKeys
        {
            get;
            internal set;
        }

        /// <summary>
        /// �����Ķ�����ǰ׺�б�
        /// </summary>
        public IList<string> CommonPrefixes
        {
            get {
                
                return this.commonPrefixes ?? (this.commonPrefixes = new List<string>()); }
            internal set { this.commonPrefixes = value; }
        }


        /// <summary>
        /// ��������Զ��������з�����ַ���
        /// </summary>
        public string Delimiter
        {
            get;
            internal set;
        }

        /// <summary>
        /// Ͱ������λ��
        /// </summary>
        public string Location
        {
            get;
            internal set;
        }

    }
   }
    
