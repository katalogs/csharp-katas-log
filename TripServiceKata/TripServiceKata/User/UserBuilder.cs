using System;

namespace TripServiceKata.User
{
    /// <summary>
    /// Builder for the class <see cref="User">User</see>
    /// </summary>
    public class UserBuilder
	{
        private User[] _friends = Array.Empty<User>();

        private Trip.Trip[] _trips =  Array.Empty<Trip.Trip>();

        /// <summary>
        /// Create a new instance for the <see cref="UserBuilder">UserBuilder</see>
        /// </summary>
        public UserBuilder()
		{
			Reset();
		}

		/// <summary>
		/// Reset all properties' to the default value
		/// </summary>
		/// <returns>Returns the <see cref="UserBuilder">UserBuilder</see> with the properties reseted</returns>
		public UserBuilder Reset()
		{
			return this;
		}

		/// <summary>
		/// Build a class of type <see cref="User">User</see> with all the defined values
		/// </summary>
		/// <returns>Returns a <see cref="User">User</see> class</returns>
		public User Build()
        {
            var user = new User();
            foreach (Trip.Trip trip in _trips)
            {
                user.AddTrip(trip);
            }

            foreach (User friend in _friends)
            {
                user.AddFriend(friend);
            }
			return user;
		}

        public UserBuilder FriendWith(params User[] friends)
        {
            this._friends = friends;
            return this;
        }

        public UserBuilder WithTrips(params Trip.Trip[] trips)
        {
            this._trips = trips;
            return this;
        }

        public static UserBuilder AUser()
        {
            return new UserBuilder();
        }
    }
}
