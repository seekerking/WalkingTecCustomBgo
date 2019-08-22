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
namespace OBS.Model
{
    /// <summary>
    /// �����������ù���
    /// </summary>
    public class ReplicationRule
    {


        /// <summary>
        ///  ����ID���ɲ�����255���ַ����ַ�����ɡ�
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// ������ƥ��Ķ�����ǰ׺��  
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ�����Ա�ʶ��Щ�������ƥ�䵽��ǰ�������򡣿�Ϊ���ַ���������ƥ��Ͱ�����ж���
        /// </para>
        /// </remarks>
        public string Prefix
        {
            get;
            set;
        }

        /// <summary>
        /// ����״̬��
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public RuleStatusEnum Status
        {
            get;
            set;
        }

        /// <summary>
        /// Ŀ��Ͱ����
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public string TargetBucketName
        {
            get;
            set;
        }

        /// <summary>
        /// ����Ĵ洢���͡�
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public StorageClassEnum? TargetStorageClass
        {
            get;
            set;
        }

    }
}
