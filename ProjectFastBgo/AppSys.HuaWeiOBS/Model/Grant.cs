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
    /// ����Ȩ���û�/�û��鼰���Ӧ��Ȩ����Ϣ��
    /// </summary>
    public class Grant
    {
        

        /// <summary>
        /// ����Ȩ���û�/�û��顣
        /// </summary>
        public Grantee Grantee
        {
            get;
            set;
        }

        /// <summary>
        /// Ȩ����Ϣ��
        /// </summary>
        public PermissionEnum? Permission
        {
            get;
            set;
        }

        /// <summary>
        /// Ͱ�ķ���Ȩ�޴��ݱ�ʶ��ֻ��ͰȨ����Ч��
        /// </summary>
        public bool Delivered
        {
            set;
            get;
        }

    }
}
