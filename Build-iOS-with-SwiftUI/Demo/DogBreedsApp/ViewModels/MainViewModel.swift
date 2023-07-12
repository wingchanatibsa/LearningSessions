//
//  MainViewModel.swift
//  DogBreedsApp
//
//  Created by Wing on 7/10/23.
//

import Foundation

class MainViewModel : ObservableObject {
    let pageTitle: String = "Dog Breeds"
    
    func getBreedsAysnc() async throws -> [Breed]? {
        let url = URL(string: "https://dog.ceo/api/breeds/list/all")!
        let (data, _) = try await URLSession.shared.data(from: url)
        
        if let message = try? JSONDecoder().decode(BreedsListResponse.self, from: data) {
            let items = message.message
            let breeds = items.keys.map{name -> Breed in
                return Breed(name: name)
            }
            return breeds.sorted()
        }
        return nil
    }
}
