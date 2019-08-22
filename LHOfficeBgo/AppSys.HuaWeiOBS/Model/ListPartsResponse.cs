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
    /// �о����ϴ��Ķε���Ӧ�����
    /// </summary>
    public class ListPartsResponse : ObsWebServiceResponse
    {

        private IList<PartDetail> parts;

        /// <summary>
        /// Ͱ����
        /// </summary>
        public string BucketName
        {
            get;
            internal set;
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string ObjectKey
        {
            get;
            internal set;
        }

        /// <summary>
        /// �ֶ��ϴ������ID��
        /// </summary>
        public string UploadId
        {
            get;
            internal set;
        }

        /// <summary>
        /// ���оٶε���ʼλ�á�
        /// </summary>
        public int? PartNumberMarker
        {
            get;
            internal set;
        }


        /// <summary>
        /// �´��������ʼλ�á�
        /// </summary>
        public int? NextPartNumberMarker
        {
            get;
            internal set;
        }

        /// <summary>
        /// �о����ϴ��ε������Ŀ���� 
        /// </summary>
        public int? MaxParts
        {
            get;
            internal set;
        }

        /// <summary>
        /// �ж��оٽ���Ƿ񱻽ضϡ�
        ///  true��ʾ�ضϣ�����û�з���ȫ�������false��ʾδ�ضϣ������Ѿ�������ȫ�������
        /// </summary>
        public bool IsTruncated
        {
            get;
            internal set;
        }

        /// <summary>
        /// ���ϴ��Ķ��б�
        /// </summary>
        public IList<PartDetail> Parts
        {
            get {
                
                return this.parts ?? (this.parts = new List<PartDetail>()); }
            internal set { this.parts = value; }
        }

        /// <summary>
        /// �ֶ��ϴ�����Ĵ����ߡ�
        /// </summary>
        public Initiator Initiator
        {
            get;
            internal set;
        }

        /// <summary>
        /// �ֶ��ϴ�����������ߡ�
        /// </summary>
        public Owner Owner
        {
            get;
            internal set;
        }

        /// <summary>
        /// �ֶ��ϴ������������ɶ���Ĵ洢���͡�
        /// </summary>
        public StorageClassEnum? StorageClass
        {
            get;
            internal set;
        }

    }
}
    
