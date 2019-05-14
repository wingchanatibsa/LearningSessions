import 'package:flutter/material.dart';
import './home_view_cell.dart';
import '../services/data_service.dart';

class HomePage extends StatefulWidget {
  @override
  State<StatefulWidget> createState() {
    return _HomePageState();
  }
}

class _HomePageState extends State<HomePage> {
  List _items = [];

  _fetchData() async {
    var items = await dataService.getBreedNamesList();

    this.setState(() {
      this._items = items;
    });
  }

  @override
  void initState() {
    super.initState();

    _fetchData();
  }

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        backgroundColor: Colors.green,
        appBar: AppBar(
          backgroundColor: Colors.green,
          title: Text("Flutter Demo"),
        ),
        body: Center(
            child: ListView.builder(
          itemCount: _items.length,
          itemBuilder: (context, index) {
            return new ViewCell(items: _items, index: index);
          },
        )),
      ),
    );
  }
}
