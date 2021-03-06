﻿namespace SharpCache
{
    #region Using Directives
    using System;
    using Microsoft.Practices.Prism.Logging;
    using SharpCache.Interfaces;
    #endregion

    internal class Cache : ICache
    {
        #region Fields

        private CacheProxy proxy;

        #endregion

        #region Constructors

        public Cache(string name, CacheConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new NullReferenceException("CacheConfiguration is NULL."); 
            }

            if (configuration.Logger != null)
            {
                configuration.Logger.Log("Create a new cache: " + name, Category.Info, Priority.High);
            }

            this.proxy = new CacheProxy(name, configuration);
        }

        #endregion

        #region Properties

        public string Name
        {
            get
            {
                return this.proxy.Name;
            }
        }

        public CacheValue this[CacheKey key]
        {
            get
            {
                return this.proxy[key];
            }

            set
            {
                this.proxy[key] = value;
            }
        }

        #endregion

        #region Public Methods

        public bool Exists(CacheKey key)
        {
            return this.proxy.Exists(key);
        }

        public void Clear()
        {
            this.proxy.Clear();
        }

        public void Adjust(CacheConfiguration configuration)
        {
            this.proxy.Adjust(configuration);
        }

        public string Dump()
        {
            return this.proxy.Dump();
        }

        #endregion
    }
}
