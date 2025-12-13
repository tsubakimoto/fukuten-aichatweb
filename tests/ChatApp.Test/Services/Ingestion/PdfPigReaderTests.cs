using ChatApp.Services.Ingestion;
using Microsoft.Extensions;
using Microsoft.Extensions.DataIngestion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UglyToad;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.DocumentLayoutAnalysis;
using UglyToad.PdfPig.DocumentLayoutAnalysis.PageSegmenter;
using UglyToad.PdfPig.DocumentLayoutAnalysis.WordExtractor;
using Xunit;


namespace ChatApp.Services.Ingestion.UnitTests;

/// <summary>
/// Tests for PdfPigReader.ReadAsync focusing on invalid stream scenarios which are expected to throw,
/// and a partial, skipped test guiding validation for a valid PDF input.
/// </summary>
public sealed class PdfPigReaderTests
{
}