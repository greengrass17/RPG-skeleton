﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("ItemCollection")]
public class ItemContainer {

	[XmlArray("Items")]
	[XmlArrayItem("Item")]
	public List<Item> items = new List<Item>();

	public static ItemContainer Load(string path) {
		TextAsset _xml = Resources.Load<TextAsset>(path);
		StringReader reader = new StringReader(_xml.text);
		XmlSerializer serializer = new XmlSerializer(typeof(ItemContainer));
		ItemContainer items = serializer.Deserialize(reader) as ItemContainer;
		reader.Close();

		return items;
	}
}
