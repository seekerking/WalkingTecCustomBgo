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
    /// ����Ͱ���������
    /// </summary>
    public class CreateBucketRequest : ObsBucketWebServiceRequest
    {

        private IDictionary<ExtensionBucketPermissionEnum, IList<string>> extensionPermissionMap;

        /// <summary>
        /// Ϊ�û�����OBSͰ��չȨ�ޡ�
        /// </summary>
        /// <param name="domainId">�û���domainId��</param>
        /// <param name="extensionPermissionEnum">OBS��չȨ�ޡ�</param>
        public void GrantExtensionPermission(string domainId, ExtensionBucketPermissionEnum extensionPermissionEnum)
        {
            if(string.IsNullOrEmpty(domainId))
            {
                return;
            }

            IList<string> domainIds;

            ExtensionPermissionMap.TryGetValue(extensionPermissionEnum, out domainIds);

            if(domainIds == null)
            {
                domainIds = new List<string>();
                ExtensionPermissionMap.Add(extensionPermissionEnum, domainIds);
            }
            domainId = domainId.Trim();
            if (!domainIds.Contains(domainId))
            {
                domainIds.Add(domainId);
            }

        }

        /// <summary>
        /// �����û���OBSͰ��չȨ�ޡ�
        /// </summary>
        /// <param name="domainId">�û���domainId��</param>
        /// <param name="extensionPermissionEnum">OBS��չȨ�ޡ�</param>
        public void WithDrawExtensionPermission(string domainId, ExtensionBucketPermissionEnum extensionPermissionEnum)
        {
            if (string.IsNullOrEmpty(domainId))
            {
                return;
            }

            IList<string> domainIds;
            ExtensionPermissionMap.TryGetValue(extensionPermissionEnum, out domainIds);
            domainId = domainId.Trim();
            if (domainIds != null && domainIds.Contains(domainId))
            {
                domainIds.Remove(domainId);
            }
        }

        internal IDictionary<ExtensionBucketPermissionEnum, IList<string>> ExtensionPermissionMap
        {
            get
            {
                return extensionPermissionMap ?? (extensionPermissionMap = new Dictionary<ExtensionBucketPermissionEnum, IList<string>>());
            }
        }

        /// <summary>
        /// ��Ͱʱ��ָ����Ͱ�Ĵ洢���͡�
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public StorageClassEnum? StorageClass
        {
            get;
            set;
        }


        /// <summary>
        /// ��Ͱʱ��ָ����Ԥ������ʲ��ԡ�
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public CannedAclEnum? CannedAcl
        {
            get;
            set;
        }


        /// <summary>
        /// ��Ͱʱ��ָ���ļ�Ⱥ���͡�
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public AvailableZoneEnum? AvailableZone
        {
            get;
            set;
        }

        /// <summary>
        /// Ͱ����
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// Ͱ�����������£�
        /// 1. 3��63���ַ������ֻ���ĸ��ͷ��֧��Сд��ĸ�����֡���-������.����
        /// 2. ��ֹʹ��IP��ַ��
        /// 3.��ֹ�ԡ�-����.����ͷ����β��
        /// 4.��ֹ������.�����ڣ��磺��my..bucket������
        /// 5.��ֹ��.���͡�-�����ڣ��磺��my-.bucket���͡�my.-bucket������
        /// </para>
        /// </remarks>
        public override string BucketName
        {
            get;
            set;
        }


        /// <summary>
        /// Ͱ���ڵ�����
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// ����Ͱ������ ���ʹ�õ��ն˽ڵ������Ĭ�����򣬿��Բ�Я���˲��������ʹ�õ��ն˽ڵ�������������������Я���˲���
        /// </para>
        /// </remarks>
        public string Location
        {
            get;
            set;
        }

        internal override string GetAction()
        {
            return "CreateBucket";
        }

    }
}
    
