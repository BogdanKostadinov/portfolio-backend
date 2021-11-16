using System;
using System.Collections.Generic;
using MongoDB.Driver;
using portfolio_backend.Models;

namespace portfolio_backend.Repositories
{
    public class MongoDbFeedbackRepository : IFeedbackRepository
    {
        private const string databaseName = "portfolio_backend";
        private const string collectionName = "feedbacks";

        private readonly IMongoCollection<Feedback> feedbacksCollection;

        public MongoDbFeedbackRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            feedbacksCollection = database.GetCollection<Feedback>(collectionName);
        }

        public void CreateFeedback(Feedback feedback)
        {
            feedbacksCollection.InsertOne(feedback);
        }

        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Feedback GetFeedback(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Feedback> GetFeedbacks()
        {
            throw new NotImplementedException();
        }

        public void UpdateFeedback(Feedback feedback)
        {
            throw new NotImplementedException();
        }
    }
}