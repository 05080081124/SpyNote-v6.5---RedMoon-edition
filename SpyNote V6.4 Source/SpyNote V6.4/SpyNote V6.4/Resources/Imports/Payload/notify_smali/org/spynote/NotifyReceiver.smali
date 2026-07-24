.class public Lorg/spynote/NotifyReceiver;
.super Landroid/content/BroadcastReceiver;
.source "NotifyReceiver.java"


.method public constructor <init>()V
    .locals 0
    invoke-direct {p0}, Landroid/content/BroadcastReceiver;-><init>()V
    return-void
.end method

.method public onReceive(Landroid/content/Context;Landroid/content/Intent;)V
    .locals 1

    if-nez p1, :ret
    invoke-static {p1}, Lorg/spynote/AppBootstrap;->onStart(Landroid/content/Context;)V

    :ret
    return-void
.end method
