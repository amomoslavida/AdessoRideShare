API EndPoints : 

/GetAll : Gets all the travel Plans currently in the system. Does not check published status. Used for testing.


/AddTravelPlan : Adds a new travel plan. Parameters : {
  "id": 0(auto Assign INT), 
  "from": "string",
  "to": "string",
  "date": "ISO 8601 date ", 
  "explanation": "string",
  "maxSeats": int(can not be null),
  "isPublished": boolean(can also be modified by other endpoints),
  "numberOfTravelers": int
}


/publishTravelPlan/{id} : Publishes a travel plan. Requires travel plan ID as parameter


/unPublishTravelPlan/{id} : Unpublishes a travel plan. Requires travel plan ID as parameter


/searchTravelPlanByFrom/{From} : Returns travel plans starting from given city. Requires a city name as parameter.


/searchTravelPlanByTo/{To} : Returns travel plans starting from given city. Requires a city name as parameter.


/JoinTravel/{id} : "Joins" a travel plan. Can call until all seats are taken. Requires a travel Plan ID as parameter
