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
    /// 简单通知服务配置.
    /// </summary>
    public class TopicConfiguration
    {
        List<EventTypeEnum> _events;
        List<FilterRule> _filterRules;

        /// <summary>
        /// 简单通知服务配置ID.
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string Id { get; set; }


        /// <summary>
        /// 事件通知主题的URN，当OBS检测到桶中发生特定的事件后，将会发布通知消息至该主题。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public string Topic { get; set; }

       
        /// <summary>
        /// 需要发布通知消息的事件类型列表。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public List<EventTypeEnum> Events
        { 
            get
            {
                return this._events ?? (this._events = new List<EventTypeEnum>());
            }
            set { this._events = value; } 
        }
        
        /// <summary>
        /// 事件通知配置的过滤规则列表.
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public List<FilterRule> FilterRules
        {
            get
            {
                return this._filterRules ?? (this._filterRules = new List<FilterRule>());
            }
            set { this._filterRules = value; }
        }
    }
}
