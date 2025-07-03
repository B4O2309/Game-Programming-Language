using Firebase.Database;
using Firebase.Database.Query;

namespace LAB11.Services
{
    public class FirebaseService
    {
        private readonly FirebaseClient firebase;

        public FirebaseService(string firebaseUrl)
        {
            firebase = new FirebaseClient(firebaseUrl);
        }

        public async Task PushDataAsync<T>(List<T> data, string node)
        {
            await firebase.Child(node).PutAsync(data);
        }
    }
}
