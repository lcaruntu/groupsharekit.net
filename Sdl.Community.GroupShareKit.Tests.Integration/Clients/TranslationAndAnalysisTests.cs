﻿//using Newtonsoft.Json;
//using Sdl.Community.GroupShareKit.Clients;
//using Sdl.Community.GroupShareKit.Models.Response;
//using System;
//using System.IO;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
//{
//    public class TranslationAndAnalysisTests
//    {
//        //[Theory]
//        //[InlineData("[{\"minimumMatchValue\":50,\"maximumMatchValue\":84},{\"minimumMatchValue\":85,\"maximumMatchValue\":100}]")]
//        //public async Task GetJobId(string fuzzyBand)
//        //{
//        //    var groupShareClient = await Helper.GetGroupShareClient();
//        //    var request = new TranslationAndAnalysisJobRequest(fuzzyBand);
//        //    var jobId = await groupShareClient.TranslateAndAnalysis.GetTranslateAndAnalysisJob(request);

//        //    Assert.True(jobId > 0);
//        //}

//        //[Theory]
//        //[InlineData("10")]
//        //public async Task GetTranslatableDocumentId(string jobId)
//        //{
//        //    var groupShareClient = await Helper.GetGroupShareClient();
//        //    var fileToTranslatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\FileToTranslate.txt.sdlxliff");
//        //    var tmOptionsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\TMOptions.Json");
//        //    var fileContent = new FileStream(fileToTranslatePath,FileMode.Open);
//        //    var content = new MultipartFormDataContent($"---{Guid.NewGuid()}---");
//        //    var optionsContent = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(tmOptionsPath)).ToString();
//        //    content.Add(new StreamContent(fileContent), "file", Path.GetFileName(fileToTranslatePath));
//        //    content.Add(new StringContent(optionsContent, Encoding.UTF8, "application/json"), "info");
//        //    var translationJobNo = await groupShareClient.TranslateAndAnalysis.GetTranslationJob(jobId, content);

//        //    Assert.True(translationJobNo > 0);
//        //}

//        //[Theory]
//        //[InlineData("9")]
//        //public async Task GetTranslationStatus(string translationJobNo)
//        //{
//        //    var groupShareClient = await Helper.GetGroupShareClient();
//        //    var translationJobStatus = await groupShareClient.TranslateAndAnalysis.GetTranslationStatus(translationJobNo);

//        //    Assert.IsType<TranslationStatus>(translationJobStatus.Status);
//        //    Assert.IsType<bool>(translationJobStatus.IsFinal);
//        //}

//        //[Theory]
//        //[InlineData("9")]
//        //public async Task DownloadTranslationDocument(string translationJobNo)
//        //{
//        //    var groupShareClient = await Helper.GetGroupShareClient();
//        //    var downloadedTranslationDocument = await groupShareClient.TranslateAndAnalysis.DownloadTranslationDocument(translationJobNo);

//        //    Assert.True(downloadedTranslationDocument.GetType() == typeof(byte[]) && downloadedTranslationDocument.Length != 0);
//        //}

//        //[Theory]
//        //[InlineData("9")]
//        //public async Task GetAnalysisDocumentId(string jobId)
//        //{
//        //    var groupShareClient = await Helper.GetGroupShareClient();
//        //    var analysisJobNo = await groupShareClient.TranslateAndAnalysis.GetAnalysisJob(jobId);

//        //    Assert.True(analysisJobNo > 0);
//        //}

//        //[Theory]
//        //[InlineData("9")]
//        //public async Task GetAnalysisStatus(string analysisJobNo)
//        //{
//        //    var groupShareClient = await Helper.GetGroupShareClient();
//        //    var analysisJobStatus = await groupShareClient.TranslateAndAnalysis.GetAnalysisStatus(analysisJobNo);

//        //    Assert.IsType<AnalysisStatus>(analysisJobStatus.Status);
//        //    Assert.IsType<bool>(analysisJobStatus.IsFinal);
//        //}

//        //[Theory]
//        //[InlineData("9")]
//        //public async Task GetAnalysisStatistics(string analysisJobNo)
//        //{
//        //    var groupShareClient = await Helper.GetGroupShareClient();
//        //    var analysisStatistics = await groupShareClient.TranslateAndAnalysis.GetAnalysisStatistics(analysisJobNo);

//        //    Assert.True(analysisStatistics != null);
//        //}

//        //[Theory]
//        //[InlineData("9")]
//        //public async Task DeleteJob(string jobId)
//        //{
//        //    var groupShareClient = await Helper.GetGroupShareClient();
//        //    await groupShareClient.TranslateAndAnalysis.DeleteJob(jobId);
//        //}

//        //[Theory]
//        //[InlineData("[{\"minimumMatchValue\":50,\"maximumMatchValue\":84},{\"minimumMatchValue\":85,\"maximumMatchValue\":100}]")]
//        //public async Task TranslateAndAnalysisFlow(string fuzzyBand)
//        //{
//        //    // For the Translate and Analysis flow a specific order must be followed. Below it's and example.

//        //    var groupShareClient = await Helper.GetGroupShareClient();
//        //    var fileToTranslatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\FileToTranslate.txt.sdlxliff");
//        //    var tmOptionsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\TMOptions.Json");
//        //    var request = new TranslationAndAnalysisJobRequest(fuzzyBand);
//        //    var jobId = await groupShareClient.TranslateAndAnalysis.GetTranslateAndAnalysisJob(request);

//        //    MultipartFormDataContent content = new MultipartFormDataContent($"---{Guid.NewGuid()}---");
//        //    var fileContent = new FileStream(fileToTranslatePath, FileMode.Open);
//        //    var optionsContent = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(tmOptionsPath)).ToString();
//        //    content.Add(new StreamContent(fileContent), "file", Path.GetFileName(fileToTranslatePath));
//        //    content.Add(new StringContent(optionsContent, Encoding.UTF8, "application/json"), "info");
//        //    var translationJob = await groupShareClient.TranslateAndAnalysis.GetTranslationJob(jobId.ToString(), content);

//        //    var translationJobStatus = await groupShareClient.TranslateAndAnalysis.GetTranslationStatus(translationJob.ToString());
//        //    while (translationJobStatus.IsFinal != true)
//        //    {
//        //        translationJobStatus = await groupShareClient.TranslateAndAnalysis.GetTranslationStatus(translationJob.ToString());
//        //    }

//        //    var downloadedTranslationDocument = await groupShareClient.TranslateAndAnalysis.DownloadTranslationDocument(translationJob.ToString());

//        //    var analysisJob = await groupShareClient.TranslateAndAnalysis.GetAnalysisJob(jobId.ToString());

//        //    var analysisJobStatus = await groupShareClient.TranslateAndAnalysis.GetAnalysisStatus(analysisJob.ToString());
//        //    while (analysisJobStatus.IsFinal != true)
//        //    {
//        //        analysisJobStatus = await groupShareClient.TranslateAndAnalysis.GetAnalysisStatus(analysisJob.ToString());
//        //    }

//        //    var analysisStatistics = await groupShareClient.TranslateAndAnalysis.GetAnalysisStatistics(analysisJob.ToString());

//        //    await groupShareClient.TranslateAndAnalysis.DeleteJob(jobId.ToString());
//        //}
//    }
//}
