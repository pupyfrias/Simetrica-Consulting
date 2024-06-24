﻿using Newtonsoft.Json;
using SimetricaConsulting.Application.Models;
using SimetricaConsulting.Domain.Entities.V1;

namespace SimetricaConsulting.Application.Extensions
{
    public static class AuditExtension
    {
        public static Audit ToAudit(this AuditEntry entry)
        {
            return new Audit
            {
                UserName = entry.UserName,
                Action = entry.Action.ToString(),
                TableName = entry.TableName,
                DateTime = DateTime.Now,
                PrimaryKey = JsonConvert.SerializeObject(entry.KeyValues),
                OldValues = entry.OldValues.Count == 0 ? null : JsonConvert.SerializeObject(entry.OldValues),
                NewValues = entry.NewValues.Count == 0 ? null : JsonConvert.SerializeObject(entry.NewValues),
                AffectedColumns = entry.ChangedColumns.Count == 0 ? null : JsonConvert.SerializeObject(entry.ChangedColumns)
            };
        }
    }
}