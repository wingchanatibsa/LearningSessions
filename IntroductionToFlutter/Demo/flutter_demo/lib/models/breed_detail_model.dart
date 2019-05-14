class BreedDetailModel {
    String status;
    String message;

    BreedDetailModel({
        this.status,
        this.message,
    });

    factory BreedDetailModel.fromJson(Map<String, dynamic> json) => new BreedDetailModel(
        status: json["status"],
        message: json["message"],
    );

    Map<String, dynamic> toJson() => {
        "status": status,
        "message": message,
    };
}