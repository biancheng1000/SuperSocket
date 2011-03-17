﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperSocket.SocketBase
{
    public class PerformanceData
    {
        public PerformanceRecord CurrentRecord { get; set; }
        public PerformanceRecord PreviousRecord { get; set; }

        public PerformanceData()
        {
            CurrentRecord = new PerformanceRecord();
        }

        public PerformanceData PushRecord(PerformanceRecord record)
        {
            PreviousRecord = CurrentRecord;
            CurrentRecord = record;
            CurrentRecord.RecordSpan = CurrentRecord.RecordTime.Subtract(PreviousRecord.RecordTime).TotalSeconds;
            return this;
        }
    }

    public class PerformanceRecord
    {
        public PerformanceRecord()
        {
            RecordTime = DateTime.Now;
        }

        public int TotalConnections { get; set; }
        public long TotalHandledCommands { get; set; }
        public DateTime RecordTime { get; private set; }
        public double RecordSpan { get; set; }
    }
}