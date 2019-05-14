import 'package:flutter/material.dart';
import './detail_page.dart';

class ViewCell extends StatelessWidget {
  const ViewCell({
    Key key,
    @required List items,
    @required int index,
  })  : _items = items,
        _index = index,
        super(key: key);

  final List _items;
  final int _index;

  @override
  Widget build(BuildContext context) {
    return Card(
      elevation: 1.0,
      margin: EdgeInsets.symmetric(horizontal: 10.0, vertical: 5.0),
      child: ListTile(
        title: Text("${_items[_index].toUpperCase()}",
            style: Theme.of(context).textTheme.display1),
        trailing: InkWell(
          child: Icon(Icons.chevron_right),
        ),
        onTap: () {
          Navigator.push(
              context,
              MaterialPageRoute(
                  builder: (context) =>
                      DetailPage(key: null, name: _items[_index])));
        },
      ),
    );
  }
}
