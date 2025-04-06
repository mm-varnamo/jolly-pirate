using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Jolly_Pirate.model
{
    public class Member
    {
        public string Name { get; private set; }
        public string SocialSecurityNumber { get; private set; }
        public Guid UniqueID { get; private set; }

        private readonly List<Boat> _boats = new List<Boat>();

        public Member(string name, string socialSecurityNumber)
        {
            SetName(name);
            SetSocialSecurityNumber(socialSecurityNumber);
            UniqueID = Guid.NewGuid();
        }

        public void UpdateMemberData(string? name = null, string? socialSecurityNumber = null)
        {
            if (name != null)
            {
                SetName(name);
            }

            if (socialSecurityNumber != null)
            {
                SetSocialSecurityNumber(socialSecurityNumber);
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
            if (!IsValidSSN(ssn))
                throw new ArgumentException("The social security number must be 10 digits long.");
            SocialSecurityNumber = ssn;
        }

        private bool IsValidSSN(string ssn)
        {
            return Regex.IsMatch(ssn, @"^\d{10}$");
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