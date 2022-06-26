locals {
    lambdaProjectName = "SecApiFinancialDataLoader"
    lambdaName = "Sec-Api-Financial-Data-Loader"
    dynamoDbTableName = "Sec-Api-Financial-Data"
    targetSns = "Sec-Api-Financial-Statements-To-Load"
}