import 'package:flutter/material.dart';
import '../models/breed_detail_model.dart';
import '../services/data_service.dart';

class DetailPage extends StatefulWidget {
  final String name;

  DetailPage({Key key, this.name}) : super(key: key);

  _DetailPageState createState() => _DetailPageState(this.name);
}

class _DetailPageState extends State<DetailPage> {
  final String _name;
  BreedDetailModel _model;

  _DetailPageState(this._name);

  _fetchData(name) async {
    var model = await dataService.getBreedDataByName(name);
    this.setState(() {
      this._model = model;
    });
  }

  @override
  void initState() {
    super.initState();

    _fetchData(this._name);
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      child: Scaffold(
        backgroundColor: Colors.green,
        appBar: AppBar(
          backgroundColor: Colors.green,
          title: Text("${_name.toUpperCase()}"),
        ),
        body: Center(
            child: _model != null
                ? Image.network(_model.message, fit: BoxFit.fill)
                : CircularProgressIndicator(valueColor: new AlwaysStoppedAnimation<Color>(Colors.white),)),
      ),
    );
  }
}
