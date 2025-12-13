#nullable enable
using ChatApp;
using ChatApp.Services;
using ChatApp.Services.Ingestion;
using Microsoft.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.VectorData;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ChatApp.Services.UnitTests;
/// <summary>
/// Partial tests for SemanticSearch.SearchAsync focusing on filter behavior and ingestion call ordering.
/// NOTE: VectorStoreCollection<string , IngestedChunk>.SearchAsync is non-virtual and the concrete type cannot be mocked per constraints.
/// To complete these tests, provide a real VectorStoreCollection implementation wired to return controlled IAsyncEnumerable results.
/// </summary>
public class SemanticSearchTests
{
}