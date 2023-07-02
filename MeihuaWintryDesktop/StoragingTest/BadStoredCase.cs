﻿using LiteDB;

namespace StoragingTest;

internal sealed class BadStoredCase
{
    public ObjectId? CaseId { get; set; }

    public NamedObject?[]? Numbers { get; set; }
    public NamedObject?[]? Guas { get; set; }

    public string? Notes { get; set; }
    public int?[]? Tags { get; set; }
}
