using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace Itineraire
{
    [DataContract]
    public class Itinerary
    {
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public List<Feature> features { get; set; }
        [DataMember]
        public List<double> bbox { get; set; }
        [DataMember]
        public Metadata metadata { get; set; }
    }

    [DataContract]
    public class Step
    {
        public double distance { get; set; }
        [DataMember]
        public double duration { get; set; }
        [DataMember]
        public int type { get; set; }
        [DataMember]
        public string instruction { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public List<int> way_points { get; set; }
    }

    [DataContract]
    public class Segment
    {
        [DataMember]
        public double distance { get; set; }
        [DataMember]
        public double duration { get; set; }
        [DataMember]
        public List<Step> steps { get; set; }
    }

    [DataContract]
    public class Summary
    {
        [DataMember]
        public double distance { get; set; }
        [DataMember]
        public double duration { get; set; }
    }

    [DataContract]
    public class Properties
    {
        [DataMember]
        public List<Segment> segments { get; set; }
        [DataMember]
        public Summary summary { get; set; }
        [DataMember]
        public List<int> way_points { get; set; }
    }

    [DataContract]
    public class Geometry
    {
        [DataMember]
        public List<List<double>> coordinates { get; set; }
        [DataMember]
        public string type { get; set; }
    }

    [DataContract]
    public class Feature
    {
        [DataMember]
        public List<double> bbox { get; set; }
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public Properties properties { get; set; }
        [DataMember]
        public Geometry geometry { get; set; }
    }

    [DataContract]
    public class Query
    {
        [DataMember]
        public List<List<double>> coordinates { get; set; }
        [DataMember]
        public string profile { get; set; }
        [DataMember]
        public string format { get; set; }
    }

    [DataContract]
    public class Engine
    {
        [DataMember]
        public string version { get; set; }
        [DataMember]
        public DateTime build_date { get; set; }
        [DataMember]
        public DateTime graph_date { get; set; }
    }

    [DataContract]
    public class Metadata
    {
        [DataMember]
        public string attribution { get; set; }
        [DataMember]
        public string service { get; set; }
        [DataMember]
        public long timestamp { get; set; }
        [DataMember]
        public Query query { get; set; }
        [DataMember]
        public Engine engine { get; set; }
    }

}
