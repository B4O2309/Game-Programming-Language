using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

namespace LAB12_FINAL.Services
{
    public class FirebaseUploader
    {
        private readonly FirebaseClient firebase;

        public FirebaseUploader()
        {
            firebase = new FirebaseClient("https://lab12-final-58cfa-default-rtdb.asia-southeast1.firebasedatabase.app/");
        }

        public async Task PushDataAsync<T>(string path, T data)
        {
            await firebase.Child(path).PutAsync(data);
        }
    }
}
