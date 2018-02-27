﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using FacialRecognitionApp.Services;

namespace FacialRecognitionApp.Repositories
{
    public class FaceRepository : IFaceRepsoitory
    {
        private readonly IFaceClientService _faceClientService;

        public FaceRepository(IFaceClientService faceClientService)
        {
            _faceClientService = faceClientService;
        }

        public async Task<string> Post(string data)
        {
            var base64Array = Convert.FromBase64String(data);

            var arrayContent = new ByteArrayContent(base64Array);

            return await _faceClientService.DetectFace(arrayContent);
        }
    }
}