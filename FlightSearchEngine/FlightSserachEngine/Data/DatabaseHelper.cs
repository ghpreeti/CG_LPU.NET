using FlightSserachEngine.Models;
using System;
//using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FlightSserachEngine.Data
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        //Get Sources
        public List<string> GetSources()
        {
            var sources = new List<string>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetSources", con))
            {
                cmd.CommandType =  CommandType.StoredProcedure;

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sources.Add(reader["Source"].ToString());
                    }
                }
            }

            return sources;
        }

        //Get Destinations
        public List<string> GetDestinations()
        {
            var destinations = new List<string>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetDestination", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        destinations.Add(reader["Destination"].ToString());
                    }
                }
            }

            return destinations;
        }

        //Search Flights
        public List<FlightResult> SearchFlights(string source, string destination, int persons)
        {
            var flights = new List<FlightResult>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_SearchFlights", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Source", source);
                cmd.Parameters.AddWithValue("@Destination", destination);
                cmd.Parameters.AddWithValue("@Persons", persons);

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        flights.Add(new FlightResult
                        {
                            FlightId = Convert.ToInt32(reader["FlightId"]),
                            FlightName = reader["FlightName"].ToString(),
                            FlightType = reader["FlightType"].ToString(),
                            Source = reader["Source"].ToString(),
                            Destination = reader["Destination"].ToString(),
                            PricePerSeat = Convert.ToDecimal(reader["PricePerSeat"]),
                            Persons = Convert.ToInt32(reader["Persons"]),
                            TotalCost = Convert.ToDecimal(reader["TotalCost"])
                        });
                    }
                }
            }

            return flights;
        }

        // Search Flights + Hotels
        public List<FlightHotelResult> SearchFlightsWithHotels(string source, string destination, int persons)
        {
            var results = new List<FlightHotelResult>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_SearchFlightsWithHotels", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Source", source);
                cmd.Parameters.AddWithValue("@Destination", destination);
                cmd.Parameters.AddWithValue("@Persons", persons);

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(new FlightHotelResult
                        {
                            FlightId = Convert.ToInt32(reader["FlightId"]),
                            FlightName = reader["FlightName"].ToString(),
                            FlightType = reader["FlightType"].ToString(),
                            Source = reader["Source"].ToString(),
                            Destination = reader["Destination"].ToString(),
                            PricePerSeat = Convert.ToDecimal(reader["PricePerSeat"]),

                            HotelId = Convert.ToInt32(reader["HotelId"]),
                            HotelName = reader["HotelName"].ToString(),
                            HotelType = reader["HotelType"].ToString(),
                            Location = reader["Location"].ToString(),
                            PricePerDay = Convert.ToDecimal(reader["PricePerDay"]),

                            Persons = Convert.ToInt32(reader["Persons"]),
                            FlightCost = Convert.ToDecimal(reader["FlightCost"]),
                            HotelCost = Convert.ToDecimal(reader["HotelCost"]),
                            TotalCost = Convert.ToDecimal(reader["TotalCost"])
                        });
                    }
                }
            }

            return results;
        }
    }
}




