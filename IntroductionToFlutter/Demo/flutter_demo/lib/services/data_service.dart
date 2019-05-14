import 'package:http/http.dart' as http;
import 'dart:convert';
import '../models/breed_detail_model.dart';

class DataService {
  final _baseUrl = "https://dog.ceo/api";

  Future<List> getBreedNamesList() async {
    final response = await http.get("$_baseUrl/breeds/list/all");

    final data = json.decode(response.body);
    Map<String, dynamic> message = data["message"];
    List items = [];
    message.forEach((key, value) {
      //print(key);
      items.add(key);
    });

    return items;
  }

  Future<BreedDetailModel> getBreedDataByName(name) async {
    final response = await http.get("$_baseUrl/breed/$name/images/random");

    final jsonData = json.decode(response.body);

    return BreedDetailModel.fromJson(jsonData);
  }
}

final DataService dataService = DataService();
