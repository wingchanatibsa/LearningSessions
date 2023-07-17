//
//  DetailView.swift
//  DogBreedsApp
//
//  Created by Wing on 7/10/23.
//

import SwiftUI

struct DetailView: View {
    let breedName: String
    
    //@StateObject var viewModel = DetailViewModel()
    let viewModel: DetailViewModel
    
    var body: some View {
        NavigationView{
            VStack {
                ImageView(viewModel: viewModel)
                    .edgesIgnoringSafeArea(.all)
            }
            .task {
                do {
                    try await viewModel.loadImageAsync()
                } catch {
                    print("Error while fetching image \(error)")
                }
                
            }
            .onAppear{
                viewModel.breedName = self.breedName
            }
            .navigationBarTitle("\(breedName)", displayMode: .inline)
        }
    }
}

struct ImageView: View {
    @ObservedObject var viewModel: DetailViewModel
    var body: some View {
        if let image = viewModel.image {
            Image(uiImage: image)
                .resizable()
                .aspectRatio(contentMode: .fit)
        } else {
            ProgressView()
        }
    }
}

struct DetailView_Previews: PreviewProvider {
    static var previews: some View {
        let viewModel = DetailViewModel()
        DetailView(breedName: "chow", viewModel: viewModel)
    }
}
