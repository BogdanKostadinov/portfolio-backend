using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using portfolio_backend.Models;

namespace portfolio_backend.Repositories
{
    public class MongoDbFeedbackRepository : IFeedbackRepository
    {
        private const string databaseName = "portfolio_backend";
        private const string collectionName = "feedbacks";

        private readonly FilterDefinitionBuilder<Feedback> filterBuilder = Builders<Feedback>.Filter;

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
           var filter = filterBuilder.Eq(feedback => feedback.Id, id);
            feedbacksCollection.DeleteOne(filter);
        }

        public Feedback GetFeedback(Guid id)
        {
            var filter = filterBuilder.Eq(feedback => feedback.Id, id);
            return feedbacksCollection.Find(filter).SingleOrDefault();
        }

        public List<Feedback> GetFeedbacks()
        {
            return feedbacksCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateFeedback(Feedback feedback)
        {
            var filter = filterBuilder.Eq(existingFeedback => existingFeedback.Id, feedback.Id);
            feedbacksCollection.ReplaceOne(filter, feedback);
        }
    }
}