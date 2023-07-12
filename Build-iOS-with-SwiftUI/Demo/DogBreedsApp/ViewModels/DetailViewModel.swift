//
//  DetailViewModel.swift
//  DogBreedsApp
//
//  Created by Wing on 7/10/23.
//

import Foundation
import SwiftUI

class DetailViewModel : ObservableObject {
    var breedName : String = ""
    
    @Published var image: UIImage? = nil
    
    func loadImageAsync() async throws -> Void {
        guard !breedName.isEmpty else {
            return
        }
        let breedImageUrl = URL(string: "https://dog.ceo/api/breed/\(breedName)/images/random")!
        
        let (data, _) = try await URLSession.shared.data(from: breedImageUrl)
        
        var imageURL: String = ""
        if let result = try? JSONDecoder().decode(RandomImageResponse.self, from: data) {
            imageURL = result.message
        }
        guard let url = URL(string: imageURL) else {
            return
        }
        
        URLSession.shared.dataTask(with: url) {
            data, _, error in
            if let data = data, let loadedImage = UIImage(data: data) {
                DispatchQueue.main.async {
                    self.image = loadedImage
                }
            }
        }.resume()
    }
}
