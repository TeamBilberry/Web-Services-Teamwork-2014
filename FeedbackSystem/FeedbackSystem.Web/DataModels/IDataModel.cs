namespace FeedbackSystem.Web.DataModels
{
    using System;

    public interface IDataModel<TData, TModel>
    {
        Func<TData, TModel> FromDataToModel { get; }

        Func<TModel, TData> FromModelToData { get; }
    }
}