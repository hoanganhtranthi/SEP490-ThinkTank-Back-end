﻿

using Firebase.Auth;
using Firebase.Storage;
using Microsoft.Extensions.Configuration;
using ThinkTank.Application.Services.IService;
using static ThinkTank.Domain.Enums.Enum;
using Stream = System.IO.Stream;

namespace ThinkTank.Application.Services.ImpService
{
    public class FirebaseStorageService : IFileStorageService
    {
        private readonly IConfiguration _config;
        private String ApiKey;
        private static string Bucket;
        private static string AuthEmail;
        private static string AuthPassword;
        public FirebaseStorageService(IConfiguration config)
        {
            _config = config;
            ApiKey = _config["Firebase:ApiKey"];
            Bucket = _config["Firebase:Bucket"];
            AuthEmail = _config["EmailUserName"];
            AuthPassword = _config["EmailPassword"];
        }

        public async Task<string> UploadFileAsync(Stream fileStream, string fileName,FileType type)
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

            var cancellation = new CancellationTokenSource();
            var task = new FirebaseStorage(Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true
                }
                ).Child($"{type}").Child(fileName).PutAsync(fileStream, cancellation.Token);
            try
            {
                string link = await task;
                return link;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> UploadFileResourceAsync(Stream fileStream, string fileName, ResourceType type, string name)
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

            var cancellation = new CancellationTokenSource();
            var task = new FirebaseStorage(Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true
                }
                ).Child($"{name}").Child($"{type}").Child(fileName).PutAsync(fileStream, cancellation.Token);
            try
            {
                string link = await task;
                return link;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
       
    }
}
