using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RecordManager : MonoBehaviour
{
	Dictionary<string, long> _records = new Dictionary<string, long>();
	string _path => Path.Combine(Application.persistentDataPath, "save.json");

	public void UpdateBestTime(string carName, TimeSpan time)
	{
		LoadRecords();

		long newTimeInTicks = time.Ticks;

		if (_records.ContainsKey(carName))
		{
			if (newTimeInTicks < _records[carName])
			{
				_records[carName] = newTimeInTicks;
			}
		}
		else
		{
			_records[carName] = newTimeInTicks;

		}
		SaveRecords();
	}

	public TimeSpan GetBestResult(string carName)
	{
		LoadRecords();

		if (_records.ContainsKey(carName))
		{
			return TimeSpan.FromTicks(_records[carName]);
		}

		return TimeSpan.Zero;
	}

	private void LoadRecords()
	{
		if (File.Exists(_path))
		{
			using (FileStream stream = File.Open(_path, FileMode.Open, FileAccess.Read))
			{
				using (StreamReader reader = new StreamReader(stream))
				{
					string json = reader.ReadToEnd();
					_records = JsonUtility.FromJson<SerializableDictionary>(json).ToDictionary();
				}
			}
		}
	}

	private void SaveRecords()
	{
		using (FileStream stream = new FileStream(_path, FileMode.Create, FileAccess.Write))
		{
			using (StreamWriter writer = new StreamWriter(stream))
			{
				string json = JsonUtility.ToJson(new SerializableDictionary(_records));
				writer.Write(json);
			}
		}
	}

	[Serializable]
	private class SerializableDictionary
	{
		public List<string> Keys;
		public List<long> Values;

		public SerializableDictionary(Dictionary<string, long> dictionary)
		{
			Keys = new List<string>(dictionary.Keys);
			Values = new List<long>(dictionary.Values);
		}

		public Dictionary<string, long> ToDictionary()
		{
			var dict = new Dictionary<string, long>();
			for (int i = 0; i < Keys.Count; i++)
			{
				dict[Keys[i]] = Values[i];
			}
			return dict;
		}
	}
}
