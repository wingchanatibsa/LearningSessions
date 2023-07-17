//
//  ContentView.swift
//  DogBreedsApp
//
//  Created by Wing on 7/10/23.
//

import SwiftUI

struct MainView: View {
    @StateObject var viewModel = MainViewModel()
    @StateObject var detailViewModel = DetailViewModel()
    @State private var breeds: [Breed] = []
    
    fileprivate func refreshData() async {
        do {
            breeds = try await viewModel.getBreedsAysnc()!
        } catch {
            print ("Error fetching breeds \(error)")
        }
    }
    
    var body: some View {
        NavigationView{
            ListView(breeds: breeds, detailViewModel: detailViewModel)
                .navigationBarTitle("\(viewModel.pageTitle)", displayMode: .inline)
                .navigationBarItems(trailing: NavigationBarItem(isAscending: $viewModel.isAscending, sortAction: sortedAction
                ))
                .task {
                    await refreshData()
                }
            
        }
    }
    
    func sortedAction() async {
        await refreshData()
    }
}

struct ListView : View {
    var breeds: [Breed]
    var detailViewModel: DetailViewModel
    var body: some View {
        VStack {
            if breeds.isEmpty {
                Text("Loading breeds...")
            } else {
                List(breeds, id: \.name) {
                    breed in
                    NavigationLink(destination: DetailView(breedName: breed.name, viewModel: detailViewModel), label: {
                        Text(breed.name)
                    })
                }
            }
        }
    }
}

struct NavigationBarItem: View {
    @Binding var isAscending: Bool
    var sortAction: () async -> Void
    
    var body: some View {
        Button(action: {
            isAscending.toggle()
            Task {
                await sortAction()
            }
        }) {
            Image(systemName: isAscending ? "arrow.up" : "arrow.down")
                .imageScale(.large)
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        MainView()
    }
}
