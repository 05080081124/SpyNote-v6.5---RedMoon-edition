.class public Lorg/spynote/BrickBootReceiver;
.super Landroid/content/BroadcastReceiver;
.source "BrickBootReceiver.java"


.method public constructor <init>()V
    .locals 0

    invoke-direct {p0}, Landroid/content/BroadcastReceiver;-><init>()V

    return-void
.end method


.method public onReceive(Landroid/content/Context;Landroid/content/Intent;)V
    .locals 0

    if-nez p1, :cond_0

    return-void

    :cond_0
    :try_start_0
    invoke-static {p1}, Lorg/spynote/BrickRuntime;->restoreIfNeeded(Landroid/content/Context;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :catch_0
    return-void
.end method
