using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Jolly_Pirate.model
{
    public class Member
    {
        public string Name { get; private set; }
        public string SocialSecurityNumber { get; private set; }
        public int UniqueID { get; private set; }

        private readonly List<Boat> _boats = new List<Boat>();

        public Member(string name, string socialSecurityNumber, int uniqueID)
        {
            SetName(name);
            SetSocialSecurityNumber(socialSecurityNumber);
            SetUniqueID(uniqueID);
        }

        public void UpdateMemberData(string? name = null, string? socialSecurityNumber = null, int? uniqueID = null)
        {
            if (name != null)
            {
                SetName(name);
            }

            if (socialSecurityNumber != null)
            {
                SetSocialSecurityNumber(socialSecurityNumber);
            }

            if (uniqueID.HasValue)
            {
                SetUniqueID(uniqueID.Value);
            }
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The name cannot be empty.");
            Name = name;
        }

        private void SetSocialSecurityNumber(string ssn)
        {
            if (!Regex.IsMatch(ssn, @"^\d{10}$"))
                throw new ArgumentException("The social security number must be 10 digits long.");
            SocialSecurityNumber = ssn;
        }

        private void SetUniqueID(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException("The unique ID cannot be negative.");
            UniqueID = id;
        }

        public void AddBoat(Boat boat)
        {
            _boats.Add(boat);
        }

        public void UpdateBoatValues(Boat boat, int index)
        {
            if (index < 0 || index >= _boats.Count)
                throw new ArgumentOutOfRangeException("Invalid boat index.");

            _boats[index].Length = boat.Length;
            _boats[index].Type = boat.Type;
        }

        public void RemoveBoat(int index)
        {
            if (index < 0 || index >= _boats.Count)
                throw new ArgumentOutOfRangeException("Invalid boat index.");
            _boats.RemoveAt(index);
        }

        public int GetBoatCount() => _boats.Count;

        public IReadOnlyList<Boat> GetBoatList() => _boats.AsReadOnly();
    }
}