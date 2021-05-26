# Template-API-Service-Pattern

## Available enpoints (Update with your localhost:XXXX)
* [Get] http://localhost:5000/template-api/v1/notes/{id}
* [Get] http://localhost:5000/template-api/v1/notes  (Get All items)

* [Post] http://localhost:5000/template-api/v1/notes
    * Payload ex:
        *  {
             "NoteId" : "2",
             "Message" : "this is amazing 2.0"
           }
    * Response ex:
        * {
            "noteId": "2",
            "message": "this is amazing 2.0",
            "messageCreatedDate": "0001-01-01T00:00:00",
            "id": "01ddf1d4-19b0-4f04-9fc8-d9a582b4bf8e"
          }

* [Delete] http://localhost:5000/template-api/v1/notes/{id}

* [Update] http://localhost:5000/template-api/v1/notes
    * Payload ex:
        *  {
             "NoteId" : "2",
             "Message" : "this is amazing 2.0.1"
           }
    * Response ex:
        * Bool (true or false)

