﻿/*
 * Copyright 2013 XPFriend Community.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Collections.Specialized;
using System.Configuration;

namespace XPFriend.Junk.Temp
{
    internal class ConfigManager
    {
        private NameValueCollection config = new NameValueCollection();

        public static ConfigManager Instance 
        {
            get { return Classes.NewInstance<ConfigManager>(); }
        }

        public ConfigManager() 
        { 
            Initialize(); 
        }

        public virtual void Initialize()
        {
            config.Clear();
            ConfigurationManager.RefreshSection("xjc.config");
            try
            {
                NameValueCollection collection = (NameValueCollection)ConfigurationManager.GetSection("xjc.config");
                if (collection != null)
                {
                    config.Add(collection);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.Ignore(e);
            }
        }

        public virtual string Get(string key, string defaultValue)
        {
            string value = config[key];
            if (value == null)
            {
                value = defaultValue;
            }
            return value;
        }

        public virtual void Put(string key, string value)
        {
            if (value == null)
            {
                config.Remove(key);
            }
            else
            {
                config[key] = value;
            }
        }
    }
}
