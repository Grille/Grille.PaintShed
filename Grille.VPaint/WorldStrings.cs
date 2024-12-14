using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grille.VPaint.IO.Cfg;

namespace Grille.VPaint;

public class WorldStrings
{
    public class StringProperty
    {
        readonly Dictionary<string, string> _dict;

        public string Key { get; }

        public bool Exists => _dict.ContainsKey(Key);

        public string Value
        {
            get
            {
                if (_dict.TryGetValue(Key, out var value))
                {
                    return value;
                }
                return string.Empty;
            }
            set
            {
                _dict[Key] = value;
            }
        }

        public StringProperty(Dictionary<string, string> dict, string key)
        {
            _dict = dict;
            Key = key;
        }

        public void Pull(CfgObject cfg)
        {
            if (cfg.Properties.TryGetValue(Key, out var value))
            {
                Value = value;
            }
            else
            {
                Value = "\"\"";
            }
        }

        public void Push(CfgObject cfg)
        {
            cfg.Properties[Key] = Value;
        }
    }

    public Dictionary<string, string> Dict { get; }

    public StringProperty Alias { get; }

    public StringProperty Kuid { get; }

    public StringProperty Name { get; }

    public StringProperty Username { get; }

    public StringProperty Description { get; }

    public StringProperty Company { get; }

    public StringProperty Origin { get; }

    public StringProperty Region { get; }

    public StringProperty Era { get; }

    public WorldStrings()
    {
        Dict = new();

        Alias = new(Dict, "alias");
        Kuid = new(Dict, "kuid");
        Name = new(Dict, "name");
        Username = new(Dict, "username");
        Description = new(Dict, "description");
        Company = new(Dict, "company");
        Origin = new(Dict, "origin");
        Region = new(Dict, "category-region-0");
        Era = new(Dict, "category-era-0");
    }

    public void Pull(CfgObject cfg)
    {
        Kuid.Pull(cfg);
        Name.Pull(cfg);
        Description.Pull(cfg);
        Company.Pull(cfg);
        Origin.Pull(cfg);
        Region.Pull(cfg);
        Era.Pull(cfg);

        Alias.Value = Kuid.Value;
        Username.Value = Name.Value;

        Kuid.Value = "<KUID:0:0>";
    }

    public void Push(CfgObject cfg)
    {
        Alias.Push(cfg);
        Kuid.Push(cfg); 
        Name.Push(cfg);
        Username.Push(cfg); 
        Description.Push(cfg);
        Company.Push(cfg); 
        Origin.Push(cfg);
        Region.Push(cfg);
        Era.Push(cfg);

        cfg.Properties["asset-filename"] = Name.Value;
    }
}
