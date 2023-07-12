//
//  ContentView.swift
//  DogBreedsApp
//
//  Created by Wing on 7/10/23.
//

import SwiftUI

struct MainView: View {
    @StateObject var viewModel = MainViewModel()
    @State private var breeds: [Breed] = []
    
    var body: some View {
        NavigationView{
            VStack {
                if breeds.isEmpty {
                    Text("Loading breeds...")
                } else {
                    List(breeds, id: \.name) {
                        breed in
                        NavigationLink(destination: DetailView(breedName: breed.name), label: {
                            Text(breed.name)
                        })
                    }
                }
            }
            .navigationBarTitle("\(viewModel.pageTitle)", displayMode: .inline)
            .task {
                do {
                    breeds = try await viewModel.getBreedsAysnc()!
                } catch {
                    print ("Error fetching breeds \(error)")
                }
            }

        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        MainView()
    }
}
