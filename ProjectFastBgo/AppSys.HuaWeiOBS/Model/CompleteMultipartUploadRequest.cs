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
    /// �ϲ��ε����������
    /// </summary>
    public class CompleteMultipartUploadRequest : ObsBucketWebServiceRequest
    {
        internal override string GetAction()
        {
            return "CompleteMultipartUpload";
        }

        private IList<PartETag> partETags;


        /// <summary>
        /// ��������
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        ///  </para> 
        /// </remarks>
        public string ObjectKey
        {
            get;
            set;
        }


        /// <summary>
        /// ���ϲ��Ķ��б�
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        ///  </para> 
        /// </remarks>
        public IList<PartETag> PartETags
        {
            get
            {
                return this.partETags ?? (this.partETags = new List<PartETag>());
            }
            set { this.partETags = value; }
        }

        /// <summary>
        /// ��Ӷ���Ϣ�����ϲ��Ķ��б�
        /// </summary>
        /// <param name="partETags">����Ӷ���Ϣ��</param>
        public void AddPartETags(params PartETag[] partETags)
        {
            foreach (PartETag part in partETags)
            {
                this.PartETags.Add(part);
            }
        }

        /// <summary>
        ///  ��Ӷ���Ϣ�����ϲ��Ķ��б�
        /// </summary>
        /// <param name="partETags">����Ӷ���Ϣ��</param>
        public void AddPartETags(IEnumerable<PartETag> partETags)
        {
            foreach (PartETag part in partETags)
            {
                this.PartETags.Add(part);
            }
        }

        /// <summary>
        /// �ӷֶ��ϴ�����Ӧ��ȡ������Ϣ����ӵ����ϲ��Ķ��б�
        /// </summary>
        /// <param name="responses">�ֶ��ϴ�����Ӧ��</param>
        public void AddPartETags(params UploadPartResponse[] responses)
        {
            foreach (UploadPartResponse response in responses)
            {
                this.PartETags.Add(new  PartETag(response.PartNumber, response.ETag));
            }
        }

        /// <summary>
        /// �ӷֶ��ϴ�����Ӧ��ȡ������Ϣ����ӵ����ϲ��Ķ��б�
        /// </summary>
        /// <param name="responses">�ֶ��ϴ�����Ӧ��</param>
        public void AddPartETags(IEnumerable<UploadPartResponse> responses)
        {
            foreach (UploadPartResponse response in responses)
            {
                this.PartETags.Add(new PartETag(response.PartNumber, response.ETag));
            }
        }

        /// <summary>
        ///�ӿ����ε���Ӧ��ȡ������Ϣ����ӵ����ϲ��Ķ��б�
        /// </summary>
        /// <param name="responses">�����ε���Ӧ��</param>
        public void AddPartETags(params CopyPartResponse[] responses)
        {
            foreach (CopyPartResponse response in responses)
            {
                this.PartETags.Add(new PartETag(response.PartNumber, response.ETag));
            }
        }

        /// <summary>
        /// �ӿ����ε���Ӧ��ȡ������Ϣ����ӵ����ϲ��Ķ��б�
        /// </summary>
        /// <param name="responses">�����ε���Ӧ��</param>
        public void AddPartETags(IEnumerable<CopyPartResponse> responses)
        {
            foreach (CopyPartResponse response in responses)
            {
                this.PartETags.Add(new PartETag(response.PartNumber, response.ETag));
            }
        }

        /// <summary>
        /// �ֶ��ϴ������ID��
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        ///  </para> 
        /// </remarks>
        public string UploadId
        {
            get;
            set;
        }

    }
}
    
