﻿using Service.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatServices
{
    public class LoggingService
    {
        private IEnumerable<ILoggingProvider> loggingProviders;
        private IStreamingService streamingService;

        public LoggingService(IEnumerable<ILoggingProvider> loggingProviders, IStreamingService streamingService) 
        { 
            this.loggingProviders = loggingProviders; 
            this.streamingService = streamingService; 
        }

        public async Task LogMessage(string message, SeverityLevel severity)
        {
            if (!streamingService.IsStreamLive) return;

            foreach(var provider in loggingProviders)
            {
                await provider.LogMessage(message, severity).ConfigureAwait(false);
            }

            return;
        }

        public async Task LogMessage(Exception message, SeverityLevel severity)
        {
            if (!streamingService.IsStreamLive) return;

            foreach (var provider in loggingProviders)
            {
                await provider.LogMessage(message, severity).ConfigureAwait(false);
            }

            return;
        }




    }
}
