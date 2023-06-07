﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;
        public string Type { get; set; }
        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();
        }

        public void Add(Car car)
        {
            if (this.Capacity > 0)
            {
                this.data.Add(car);
                this.Capacity--;
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car carToRemove = this.data.Find(x => x.Manufacturer == manufacturer && x.Model == model);
            if (carToRemove == null)
            {
                return false;
            }

            this.Capacity++;
            return true;
        }

        public Car GetLatestCar()
        {
            Car latestCar = this.data.OrderByDescending(c => c.Year).FirstOrDefault();
            return latestCar ?? null;
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car carToGet = this.data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
            return carToGet ?? null;
        }
        
        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (var car in this.data)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}