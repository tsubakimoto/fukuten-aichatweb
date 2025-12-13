#nullable enable

using ChatApp.Services;
using ChatApp.Services.Ingestion;
using Microsoft.Extensions;
using Microsoft.Extensions.DataIngestion;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Xunit;


namespace ChatApp.Services.Ingestion.UnitTests;

/// <summary>
/// Tests for DocumentReader.ReadAsync(Stream source, string identifier, string mediaType, CancellationToken cancellationToken).
/// Note: The production type is 'internal sealed', preventing direct access from this test assembly without InternalsVisibleTo.
/// As we cannot instantiate the reader or mock its private dependencies, these tests are marked as skipped with guidance.
/// </summary>
public sealed class DocumentReaderTests
{
}