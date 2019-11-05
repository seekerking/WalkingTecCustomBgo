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
    /// Ͱ��ǩ��
    /// </summary>
    public class Tag
    {
        

        /// <summary>
        /// ��ǩ���� 
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// ���36���ַ������԰�����A-Z��a-z��0-9����-������_���Լ�Unicode(\u4E00-\u9FFF)��ͬһ��Ͱ��Tag��Key�����ظ���
        /// </para>
        /// </remarks>
        public string Key
        {
            get;
            set;
        }

        /// <summary>
        /// ��ǩֵ�� 
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// ���ֵΪ43���ַ������԰�����A-Z��a-z��0-9����-������_������.���Լ�Unicode(\u4E00-\u9FFF)��
        /// </para>
        /// </remarks>
        public string Value
        {
            get;
            set;
        }

    }
}
